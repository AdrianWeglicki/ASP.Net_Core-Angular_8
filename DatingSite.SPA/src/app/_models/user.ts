import {Photo} from './photo';

export interface User {

    id: number;
    username: string;
    gender: string;
    age: number;
    created: string;
    city: string;
    country: string;
    growth: string;
    eyeColor: string;
    hairColor: string;
    maritalStatus: string;
    education: string;
    profession: string;
    children: string;
    languages?: any;
    motto: string;
    description: string;
    personality: string;
    lookingFor: string;
    interests: string;
    freeTime: string;
    sport: string;
    movies: string;
    music: string;
    iLike: string;
    idoNotLike: string;
    makesMeLaugh: string;
    itFeelsBestIn: string;
    friendWouldDescribeMe: string;
    photos: Photo[];
    photoUrl: string;


}
