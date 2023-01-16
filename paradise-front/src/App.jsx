import React from 'react'
import AuthWindow from './Components/AuthWindow/AuthWindow'
import Navigation from './Components/NavigationPanel/Navigation'

const App = () => {
  return (
    <div>
        <Navigation></Navigation>
        <AuthWindow/>
    </div>
  )
}

export default App