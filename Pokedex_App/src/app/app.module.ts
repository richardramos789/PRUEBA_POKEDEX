import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { SearchComponent } from './components/search/search.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';

// Importar Routes
import { ROUTES } from './app.routes'; 
import { TarjetasComponent } from './components/tarjetas/tarjetas.component';
import { LoadingComponent } from './components/shared/loading/loading.component';
import { ImagePokemonPipe } from './pipes/image-pokemon.pipe';
import { IdPokemonPipe } from './pipes/id-pokemon.pipe';
import { InformationPokemonComponent } from './components/information-pokemon/information-pokemon.component';
import { ConvertWeightAndHeightPipe } from './pipes/convert-weight-and-height.pipe';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SearchComponent,
    NavbarComponent,
    ImagePokemonPipe,
    TarjetasComponent,
    LoadingComponent,
    IdPokemonPipe,
    InformationPokemonComponent,
    ConvertWeightAndHeightPipe
  ],
  imports: [
    BrowserModule, 
    HttpClientModule,
    RouterModule.forRoot( ROUTES, { useHash: true } )
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
