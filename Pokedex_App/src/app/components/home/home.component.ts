import { Component, OnInit } from '@angular/core';
import { PokedexService } from '../../services/pokedex.service';

@Component({   
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent  {

  Pokemon: any[] = [];
  loading: boolean;
  error: boolean;

  constructor( private _Pokedex: PokedexService) {

    this.loading = true;
    this.error = false;

    this._Pokedex.ObtenerPokemon()
        .subscribe( (data: any) => {
          this.Pokemon = data;
          this.loading = false;
        }, (_error) => {
          this.loading = false;
          this.error = true;
        });
   }




}
