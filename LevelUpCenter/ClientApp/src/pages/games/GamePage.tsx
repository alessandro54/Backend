import { useEffect, useState } from "react";
import {useParams} from "react-router-dom";

const GamePage = () => {
    const [gameId, setGameId] = useState<string>("")
    const params = useParams();
    
    useEffect(() => {
        setGameId(params.gameId as string);
    }, [])
    return (
        <div>
            <h1>{gameId}</h1>
        </div>
    );
}

export default GamePage;