import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DrawHistory } from './draw-history/draw-history.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) { }

  getHistory(): Observable<DrawHistory[]> {
    return this.httpClient.get<DrawHistory[]>('api/historyDraw');
  }

  saveDraw(newDraw: DrawHistory): Observable<any> {
    return this.httpClient.post('api/historyDraw', newDraw)
  }
}
