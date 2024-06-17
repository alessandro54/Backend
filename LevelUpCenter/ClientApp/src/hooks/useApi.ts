import {useEffect, useState} from "react";


interface ApiOptions {
    method?: 'GET' | 'POST' | 'PUT' | 'DELETE';
    body?: any;
    headers?: Record<string, string>;
}
const useApi = (path, opts : ApiOptions) => {
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    
    useEffect(() => {
        const fetchDate = async () => {
            try {
                setLoading(true);
                const response = await fetch(`/api/v1${path}`, {
                    method: opts.method || 'GET',
                    body: JSON.stringify(opts.body),
                    headers: {
                        'Content-Type': 'application/json',
                        ...opts.headers
                    }
                })
                setData(response.d)
            }
        }
    })
}