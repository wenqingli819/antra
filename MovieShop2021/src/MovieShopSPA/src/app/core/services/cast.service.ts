import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MovieCard } from 'src/app/shared/models/movie-card';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class CastService {

  constructor(private apiService:ApiService) { }

  getMoviesByCast(id:number):Observable<MovieCard[]>{

    return this.apiService.getAll(`movies/cast/${id}`);

  }
}
