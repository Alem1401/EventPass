import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCardModule } from '@angular/material/card';
import { SponsorService } from '../../../core/services/sponsor-service';
import { Sponsor } from '../../../core/models/sponsor.model';
import { MatIcon } from "@angular/material/icon";
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'app-sponsors-list',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatCardModule,
    MatIcon,
    MatButtonModule,
    MatTooltipModule
],
  templateUrl: './sponsor-list.html',
  styleUrls: ['./sponsor-list.css']
})

export class SponsorsListComponent implements OnInit {

  sponsorService = inject(SponsorService);
  snackBar = inject(MatSnackBar);
  router = inject(Router);

  sponsors: MatTableDataSource<Sponsor> = new MatTableDataSource<Sponsor>();
  loading = true;

  displayedColumns = ['logo', 'name', 'website', 'email', 'phone', 'actions'];

  ngOnInit(): void {
    this.sponsorService.getAllSponsors().subscribe({
      next: (data) => {
        this.sponsors.data = data;
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.loading = false;
      }
    });
  }

  onClickDelete(id : number): void
  {
      if(!confirm("Are you sure you want to delete this sponsor?")) return;

      this.sponsorService.deleteSponsor(id).subscribe(
        {
          next: () => {
            this.snackBar.open('Sponsor deleted', 'Close', { duration: 3000} );
            this.ngOnInit();
          },
          error: (err) => {
            console.error(err);
            this.snackBar.open('Error deleting sponsor', 'Close', { duration : 3000});
          }
        }
      )
  }

  onAddSponsorClick(){
    this.router.navigate(['/sponsors/create']);
  }  

  onEditSponsor(id: number) {
  this.router.navigate(['/sponsors/edit', id]);
  }
}