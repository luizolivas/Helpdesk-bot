import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatButtonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  constructor(private router: Router){}

  RedirectTo(opt: number){

      if(opt == 1){
        this.router.navigate(['/chat']);
      }
      else if(opt == 2){
        this.router.navigate(['/relatar-problema']);
      }
      else if(opt == 3){
        this.router.navigate(['/status-problema']);
      }
      else {
        this.router.navigate(['/']);
      }
  }
}
