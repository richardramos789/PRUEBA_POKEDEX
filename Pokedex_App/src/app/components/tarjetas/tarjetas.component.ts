import { Component, Input } from '@angular/core';
import  { Router } from '@angular/router';
 
@Component({
  selector: 'app-tarjetas',
  templateUrl: './tarjetas.component.html',
  styleUrls: []
})
export class TarjetasComponent {

  @Input() items: any[] = [];

  constructor(private router: Router) { }

verInformacionPokemon(item: any){
    let PokemonId;
    console.log(item);
    PokemonId = item.id_pokemon
    console.log(PokemonId);
    this.router.navigate(['/pokemon', PokemonId]);
  }
}
