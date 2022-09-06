import React from 'react'
import { useSelector } from 'react-redux'

export default function HomePage() {
    const auth = useSelector(state => state.auth)
    
    return (
        <div>
            {auth.userId}
        </div>
    )
}
