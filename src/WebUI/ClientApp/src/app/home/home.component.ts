import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { DrawHistoryComponent } from '../draw-history/draw-history.component';
import { DrawHistory } from '../draw-history/draw-history.model';
import { Ball } from './ball.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  isDrawing = false;
  width = 500;
  height = 300;
  size = 15;
  balls: Ball[] = [];
  requestAnimationFrameId: number;
  results: number[];
  drawButtonText = 'Draw';

  constructor(private apiService: ApiService) {
  }

  random(min, max): number {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }

  async draw() {
    this.isDrawing = true;
    this.drawButtonText = 'Draw again';
    this.createBalls();
    this.animationLoop();
    this.results = [];
    let max = 50;
    let numbersArray = Array.from({length: max}, (_, i) => i + 1)
    await this.sleep(3000)
    for (let i = 0; i < 5; i++) {
      const index = this.random(0, --max);
      this.results.push(numbersArray[index]);
      numbersArray.splice(index, 1);
      if (i != 4) {
        await this.sleep(3000)
      } 
    }
    this.saveDraw(this.results);
    this.cancelAnimation();
    this.isDrawing = false;
  }

  createBalls() {
    while (this.balls.length < 50) {
      const ball = new Ball(
         this.random(0 + this.size, this.width - 15),
         this.random(0 + this.size, this.height - 15),
         this.random(-7,7),
         this.random(-7,7),
         this.size
      );
   
     this.balls.push(ball);
   }
  }

  animationLoop() {
    const canvas = document.querySelector('canvas');
    const ctx = canvas.getContext('2d');
    ctx.fillStyle = 'rgba(0, 0, 0, 0.25)';
    ctx.fillRect(0, 0, this.width, this.height);
 
    for (const ball of this.balls) {
      ball.render(ctx);
      ball.update();
      ball.collisionDetect(this.balls);
    }
 
    this.requestAnimationFrameId = requestAnimationFrame(this.animationLoop.bind(this));
  }

  cancelAnimation() {
    cancelAnimationFrame(this.requestAnimationFrameId);
  }

  sleep(miliSeconds: number) {
    return new Promise(resolve => setTimeout(resolve, miliSeconds));
  }

  saveDraw(results: number[]) {
    const newDraw: DrawHistory = {
      firstNumber: results[0],
      secondNumber: results[1],
      thirdNumber: results[2],
      fourthNumber: results[3],
      fifthNumber: results[4]
    }
    this.apiService.saveDraw(newDraw).subscribe();
  }
}
