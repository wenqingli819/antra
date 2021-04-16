import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from 'src/app/shared/models/movie';
import { MovieCard } from 'src/app/shared/models/movie-card';
import { ApiService } from './api.service';


@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private apiService:ApiService) { }

  getTop30GrossingMovies():Observable<MovieCard[]>{
    return this.apiService.getAll('movies/toprevenue');
  }

  getMoviesByGenre(id:number):Observable<MovieCard[]>{

    return this.apiService.getAll('movies/genre');
  }

  getMovieDetails(id:number):Observable<Movie>{
    return this.apiService.getOne(`${'/movies/'}${id}`);
  }

}
