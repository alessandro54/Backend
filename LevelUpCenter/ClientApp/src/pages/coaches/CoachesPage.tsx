import { useEffect, useState } from "react";

type Coach = {
    nickname: string,
    profilePictureUrl: string,
    twitchUrl: string,
}
const CoachesPage = () => {
    const [coaches, setCoaches] = useState<Coach[]>([])
    
    const fetchCoaches = async () => {
        return await fetch('/api/v1/coaches')
    }
    useEffect(() => {
        fetchCoaches()
            .then(response => response.json())
            .then(data => setCoaches(data));
    }, [])
    return (
        <div>
            <h1>Coaches</h1>
            <div>
                {coaches.map(coach => (
                    <div key={coach.nickname}>
                        <img src={coach.profilePictureUrl} alt={coach.nickname} />
                        <h2>{coach.nickname}</h2>
                        <a href={coach.twitchUrl}>Twitch</a>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default CoachesPage;