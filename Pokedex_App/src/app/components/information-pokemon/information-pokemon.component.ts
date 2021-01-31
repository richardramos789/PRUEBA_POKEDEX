import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PokedexService } from 'src/app/services/pokedex.service';


@Component({
  selector: 'app-information-pokemon',
  templateUrl: './information-pokemon.component.html',
  styleUrls: ['./information-pokemon.component.css']
})
export class InformationPokemonComponent {

  Pokemon: any = {};
  Base: any = {};
  loading: boolean;
  hp: string;
  attack: string;
  defence: string;
  sp_a: string;
  sp_d: string;
  speed: string;

  constructor(private router: ActivatedRoute,
    private _pokedex: PokedexService) { 
      this.loading = true;


      this.router.params.subscribe( params => {
        this.ObtenerInformacionPokemon( params['id'] );
      });
    }

    ObtenerInformacionPokemon(id: string){
      this.loading = true;
  
      this._pokedex.VerInformacionPokemon(id)
          .subscribe( data => {            
             this.Pokemon = data[0];
             this.Base = this.Pokemon.base;
             console.log(this.Base);
             this.hp = this.Base.hp + "%";
             this.attack = this.Base.attack + "%";
             this.defence = this.Base.defense + "%";
             this.sp_a = this.Base.sp_Attack + "%";
             this.sp_d = this.Base.sp_Deffense + "%";
             this.speed = this.Base.speed + "%";
             console.log(this.speed);
             this.loading = false;
      });
    }
  }
