import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PokedexService {

  constructor(private http: HttpClient) { 
    console.log('Pokedex Service Listo');
  }

ObtenerPokemon(){
  const endPoints = "api/Pokemon/PokemonByNombre";

  const Body = {
    ValorBusqueda: ""
  }
  return this.http.post(endPoints, Body).pipe( map( data => data) );
}

BuscarPokemonPorNombre(valor: string){
  const endPoints = "api/Pokemon/PokemonByNombre";
  
  const Body = {
    ValorBusqueda: valor
  }
  return this.http.post(endPoints, Body).pipe( map( data => data) );
  
}

VerInformacionPokemon(id: string){
  const endPoints = "api/Pokemon/VerInformacionPokemon";
  
  const Body = {
    idPokemon: id
  }
  return this.http.post(endPoints, Body).pipe( map( data => data) );
  
  
}

}
