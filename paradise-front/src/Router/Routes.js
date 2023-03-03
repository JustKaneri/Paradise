import VideoPage from '../Pages/VideoPage';
import AuthPage from '../Pages/AuthPage';
import ProfilePage from '../Pages/ProfilePage';
import RegestryPage from '../Pages/RegestryPage';
import SubscribPage from '../Pages/SubscribPage';
import VideoAddPage from '../Pages/VideoAddPage';
import WatchVideoPage from '../Pages/WatchVideoPage';
import NotFoundPage from '../Pages/NotFoundPage';
import FavoritePage from '../Pages/FavoritePage';
import SearchPage from '../Pages/SearchPage'

export const privatRoutes = [
    {path:"/favorite", element: <FavoritePage/>, exact: true},
    {path:'/subscribs', element: <SubscribPage/>, exact: true },
    {path:'/add-page', element: <VideoAddPage/>, exact: true }
]

export const notAuthRoutes = [ 
    {path:'/login', element: <AuthPage/>, exact: true },
    {path:'/regestry',element: <RegestryPage/>, exact: true}
]

export const publicRoutes = [
    {path:'/main', element: <VideoPage/>, exact: true },
    {path:'/not-found', element: <NotFoundPage/>, exact: true },
    {path:'/profile/:id', element: <ProfilePage/>, exact: true },
    {path:'/video/searh/:searh', element: <SearchPage/>, exact: true },
    {path:'/video/:id', element: <WatchVideoPage/>, exact: true }
]