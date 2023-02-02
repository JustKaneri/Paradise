import VideoPage from '../Pages/VideoPage';
import AuthPage from '../Pages/AuthPage';
import ProfilePage from '../Pages/ProfilePage';
import RegestryPage from '../Pages/RegestryPage';
import SubscribPage from '../Pages/SubscribPage';
import VideoAddPage from '../Pages/VideoAddPage';
import WatchVideoPage from '../Pages/WatchVideoPage';

export const privatRoutes = [
    {path:'/subscribs', element: <SubscribPage/>, exact: true },
    {path:'/add-page', element: <VideoAddPage/>, exact: true }
]

export const publicRoutes = [
    {path:'/login', element: <AuthPage/>, exact: true },
    {path:'/regestry',element: <RegestryPage/>, exact: true},
    {path:'/main', element: <VideoPage/>, exact: true },
    {path:'/profile/:id', element: <ProfilePage/>, exact: true },
    {path:'/video/searh/:searh', element: <VideoPage/>, exact: true },
    {path:'/video/:id', element: <WatchVideoPage/>, exact: true }
]