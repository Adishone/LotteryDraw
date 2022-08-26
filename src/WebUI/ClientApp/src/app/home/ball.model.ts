export class Ball {
    x: number;
    y: number;
    velocityX: number;
    velocityY: number;
    color: any;
    size: number;

    constructor(x, y, velX, velY, size) {
        this.x = x;
        this.y = y;
        this.velocityX = velX;
        this.velocityY = velY;
        this.size = size;
        this.color = 'rgb(136, 8, 8)'
    }

    render(canvasContext: any) {
        canvasContext.beginPath();
        canvasContext.fillStyle = this.color;
        canvasContext.arc(this.x, this.y, this.size, 0, 2 * Math.PI);
        canvasContext.fill();
    }

    update() {
        if ((this.x + this.size) >= 500) {
           this.velocityX = -(this.velocityX);
        }
  
        if ((this.x - this.size) <= 0) {
           this.velocityX = -(this.velocityX);
        }
  
        if ((this.y + this.size) >= 300) {
           this.velocityY = -(this.velocityY);
        }
  
        if ((this.y - this.size) <= 0) {
           this.velocityY = -(this.velocityY);
        }
  
        this.x += this.velocityX;
        this.y += this.velocityY;
    }

     
    collisionDetect(balls: Ball[]) {
        for (const ball of balls) {
            if (!(this === ball)) {
                const dx = this.x - ball.x;
                const dy = this.y - ball.y;
            }
        }
    }
      
}