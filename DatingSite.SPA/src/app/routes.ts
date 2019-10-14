import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LikesComponent } from './likes/likes.component';
import { UsersListComponent } from './users/users-list/users-list.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { UserDetailComponent } from './users/user-detail/user-detail.component';
import { UserDetailResolver } from './_resolvers/user-list.resolver';
import { UserListResolver } from './_resolvers/user-detail.resolver';


export const appRoutes: Routes = [
    {   path: '', component: HomeComponent  },
    {   path: '', runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'users', component: UsersListComponent, resolve: {users: UserListResolver}},
            { path: 'likes', component: LikesComponent},
            { path: 'messages', component: MessagesComponent},
            { path: 'users/:id', component: UserDetailComponent, resolve: {user: UserDetailResolver}}
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'}
];