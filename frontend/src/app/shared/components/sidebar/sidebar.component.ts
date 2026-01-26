import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterModule, MatListModule, MatIconModule],
  template: `
    <mat-nav-list>
      <a mat-list-item routerLink="/estudiantes">
        <mat-icon>school</mat-icon>
        Estudiantes
      </a>
      <a mat-list-item routerLink="/profesores">
        <mat-icon>person</mat-icon>
        Profesores
      </a>
      <a mat-list-item routerLink="/notas">
        <mat-icon>grading</mat-icon>
        Notas
      </a>
    </mat-nav-list>
  `,
  styles: [`
    mat-nav-list {
      color: #e5e7eb;
    }
    a {
      color: inherit;
    }
    mat-icon {
      margin-right: 12px;
    }
  `]
})
export class SidebarComponent {}
