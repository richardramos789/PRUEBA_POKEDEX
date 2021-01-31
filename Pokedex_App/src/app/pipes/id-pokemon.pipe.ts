import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'idPokemon'
})
export class IdPokemonPipe implements PipeTransform {

  transform( id: string): string {
    
    if (id.length == 1){
      return `N°. 00${id}`;
    }    
    else if (id.length == 2){
      return `N°. 0${id}`;
    }else{
      return `N°. ${id}`;
    }

  }
}