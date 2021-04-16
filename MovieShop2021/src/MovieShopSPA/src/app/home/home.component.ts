import { MovieService } from './../core/services/movie.service';
import { Component, OnInit } from '@angular/core';
import { MovieCard } from '../shared/models/movie-card';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  movies:MovieCard[] = [];
  constructor(private movieService:MovieService) { }

  ngOnInit(): void {
    this.movieService.getTop30GrossingMovies().subscribe(
      m=>{
        this.movies= m;
        console.table(this.movies);
      }
    )
  }

}
