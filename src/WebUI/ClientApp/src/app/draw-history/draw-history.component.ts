import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';


@Component({
  selector: 'app-draw-history',
  templateUrl: './draw-history.component.html',
  styleUrls: ['./draw-history.component.scss']
})
export class DrawHistoryComponent implements OnInit {
  draws: any[];
  isLoading = true;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getHistory().subscribe({
      next: (drawsResponse) => this.draws = drawsResponse,
      error: (e) => console.log(e),
      complete: () => this.isLoading = false
    });
  }

}
