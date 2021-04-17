import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';
import { Movie } from 'src/app/shared/models/movie';


@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})

export class MovieDetailsComponent implements OnInit {
  movie: Movie;
  id =-1;

  constructor(private movieService: MovieService, private route: ActivatedRoute,private router: Router) { }

  ngOnInit(){

    this.route.paramMap.subscribe(
      params => {
        this.id = Number(params.get('id'));
        this.getMovieDetails();
      }
    );
  }

  private getMovieDetails() {
    console.log(this.id);
    this.movieService.getMovieDetails(this.id)
      .subscribe(m => {
        this.movie = m;
        }

      );
   }
}


