import React from 'react'
import Loader from './Components/Loader/Loader'
import Navigation from './Components/NavigationPanel/Navigation'

const App = () => {
  return (
    <div>
        <Navigation></Navigation>
        <Loader/>
    </div>
  )
}

export default App