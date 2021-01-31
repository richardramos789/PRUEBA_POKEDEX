import { Component } from '@angular/core';
import { PokedexService } from '../../services/pokedex.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent {

  Pokemon: any[] = [];
  loading: boolean;

  constructor(private _Pokedex: PokedexService) {}

  
  buscarPokemon(palabra: string){
    this.loading = true;
    this._Pokedex.BuscarPokemonPorNombre( palabra )
        .subscribe( (data: any) => {
          this.Pokemon = data;
          this.loading = false;
        });
    
  }

}
