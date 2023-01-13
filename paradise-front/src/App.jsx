import React from 'react'
import Canal from './Components/Canal/Canal'
import ListSubscrib from './Components/ListSubscib/ListSubscrib'
import ListVideo from './Components/ListVideo/ListVideo'
import Navigation from './Components/NavigationPanel/Navigation'

const App = () => {
  return (
    <div>
        <Navigation></Navigation>
        <Canal/>
    </div>
  )
}

export default App