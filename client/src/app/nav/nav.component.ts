import { AccountService } from './../_services/account.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
  // loggedIn: boolean;
  // currentUser$: Observable<User>;

  // constructor(private accountService: AccountService) { }
  constructor(
    public accountService: AccountService,
    private router: Router,
    private toastr: ToastrService
    ) { }

  ngOnInit(): void {
    // this.getCurrentUser();
    // this.currentUser$ = this.accountService.currentUser$;
  }

  login(){
    console.log(this.model);
    this.accountService.login(this.model).subscribe(response => {
      console.log(response);
      // this.loggedIn = true;
      this.router.navigateByUrl('/members');
    }, error => {
      console.log(error);
      this.toastr.error(error.error);
    })
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
    // this.loggedIn = false;
  }

  // old method (not so clean, async is cleaner and auto unsubscribes)

  // getCurrentUser(){
  //   this.accountService.currentUser$.subscribe(user => {
  //     // !! converts a value into a boolean, so null(false) and any other value (true)
  //     this.loggedIn = !!user;
  //   }, error => {
  //     console.log(error);
  //   })
  // }

}
