import { createBrowserRouter } from "react-router-dom";
import LoginPage from "@/pages/LoginPage";
import NotFoundPage from "@/pages/NotFoundPage";
import CoachesPage from "@/pages/coaches/CoachesPage";
import GamesPage from "@/pages/games/GamesPage.tsx";
import GamePage from "@/pages/games/GamePage.tsx";

const router = createBrowserRouter([
    {
        path: '/',
        element: <div>Hello World</div>,
        errorElement: <NotFoundPage />
    },
    {
        path: '/login',
        element: <LoginPage />
    },
    {
        path: '/coaches',
        element: <CoachesPage />
    },
    {
        path: '/games',
        element: <GamesPage />,
    },
    {
        path: '/games/:gameId',
        element: <GamePage />
    }
])

export default router;