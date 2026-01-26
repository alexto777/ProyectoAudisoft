import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';

@Component({
  selector: 'app-toolbar',
  standalone: true,
  imports: [MatToolbarModule],
  template: `
    <mat-toolbar color="primary">
      <span>Proyecto Audisoft</span>
      <span class="spacer"></span>
      <span class="user">Admin</span>
    </mat-toolbar>
  `,
  styles: [`
    .spacer { flex: 1 1 auto; }
    .user { font-size: 14px; opacity: .8; }
  `]
})
export class ToolbarComponent {}
