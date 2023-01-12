import React from 'react'
import ListSubscrib from './Components/ListSubscib/ListSubscrib'
import ListVideo from './Components/ListVideo/ListVideo'
import Navigation from './Components/NavigationPanel/Navigation'

const App = () => {
  return (
    <div>
        <Navigation></Navigation>
        <ListSubscrib/>
    </div>
  )
}

export default App