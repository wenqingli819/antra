import { CastService } from './../../core/services/cast.service';
import { Component, OnInit } from '@angular/core';
import { MovieCard } from 'src/app/shared/models/movie-card';
import{ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-cast-item',
  templateUrl: './cast-item.component.html',
  styleUrls: ['./cast-item.component.css']
})
export class CastItemComponent implements OnInit {

  castmovies:  MovieCard[] = [];
  castId = -1;
  constructor(private castService:CastService,
    private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.castId = Number( params.get('id'));

      this.castService.getMoviesByCast(this.castId)
        .subscribe(c => {
          this.castmovies = c;
        });
    }
  );
  }

}
