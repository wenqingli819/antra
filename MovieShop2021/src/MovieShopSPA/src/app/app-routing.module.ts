import { CastItemComponent } from './cast/cast-item/cast-item.component';
import { LoginComponent } from './auth/login/login.component';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';
import { MovieCardListComponent } from './movies/movie-card-list/movie-card-list.component';
import { GenresComponent } from './genres/genres.component';
import { HomeComponent } from './home/home.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes =
  [
    { path: '', component: HomeComponent },
    { path: 'genre/movies/:id', component: MovieCardListComponent },
    { path: 'movies/genres/:id', component: MovieCardListComponent },
    { path: 'movies/:id', component: MovieDetailsComponent },
    { path: 'login', component:LoginComponent},
    { path: 'movies/:id/cast/movies/:id',component: CastItemComponent}
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
