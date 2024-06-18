import {useEffect, useState} from "react";
import {Card, CardContent, CardDescription, CardTitle} from "@/components/ui/card.tsx";
import {Avatar, AvatarImage} from "@/components/ui/avatar.tsx";

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
            <div className="grid grid-cols-3 p-3">
                {coaches.map(coach => (
                    <Card className="p-4" key={coach.nickname}>
                        <div>
                            <CardTitle>
                                {coach.nickname}
                            </CardTitle>
                            <CardDescription>
                                <a className="text-xs" href={coach.twitchUrl}>{coach.twitchUrl}</a>
                            </CardDescription>
                            <CardContent>
                                <Avatar>
                                    <AvatarImage src={coach.profilePictureUrl} alt={coach.nickname}/>
                                </Avatar>
                            </CardContent>
                        </div>
                    </Card>
                ))}
            </div>
        </div>
    );
}

export default CoachesPage;