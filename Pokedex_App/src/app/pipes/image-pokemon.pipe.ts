import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'imagePokemon'
})
export class ImagePokemonPipe implements PipeTransform {

  transform( images: any[]): string {
    if (!images){
      return `/assets/img/PokemonNoImage.png`;
    }
    
    if (images.length > 0){
      return `/assets/images-thumbnails/${images}`;
    }else{
      return `/assets/img/PokemonNoImage.png`;
    }
  }


}
