import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'convertWeightAndHeight'
})
export class ConvertWeightAndHeightPipe implements PipeTransform {

  transform( valor: any, tipo?: number ): string {
    if (tipo == 1){
      return (valor * 0.1).toFixed(1);
    }else if (tipo == 2){
      return (valor * 0.1).toFixed(1);
    }
}
}