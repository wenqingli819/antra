import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import {Genre} from 'src/app/shared/models/genre';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  constructor(private apiService: ApiService) { }


 //call https://localhost:44381/api/Genres
  getAllGenres():Observable<Genre[]>{
    // make a call to API to get JSON data and wrap it in Genre array and return
    // we call our base ApiService which is going t ocall our API using HttpClient class
      return this.apiService.getAll('genres');
  }

}
