import {render, screen} from '@testing-library/react';
import {http, HttpResponse} from 'msw'
import {setupServer} from 'msw/node'
import '@testing-library/jest-dom'
import CoachesPage from "@/pages/coaches/CoachesPage";

const server = setupServer(
    http.get('/greeting', () => {
        return HttpResponse.json({greeting: 'hello there'})
    }),
)

beforeAll(() => server.listen())
afterEach(() => server.resetHandlers())
afterAll(() => server.close())

test('renders coaches page', async () => {
    server.use(
        http.get('/api/v1/coaches', () => {
                return HttpResponse.json([
                    {
                        nickname: 'test',
                        profilePictureUrl: 'https://example.com/test.jpg',
                        twitchUrl: 'https://twitch.tv/test',
                        courses: []
                    },
                ])
            }
        )
    )
    // Arrange
    render(<CoachesPage/>);

    // Act
    const coachNickname = await screen.findByText("test");

    // Assert
    expect(coachNickname).toBeInTheDocument();
});