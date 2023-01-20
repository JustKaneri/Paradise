import React from 'react'
import AuthWindow from './Components/AuthWindow/AuthWindow'
import Navigation from './Components/NavigationPanel/Navigation'
import WatchVideoPage from './Pages/WatchVideoPage'

const App = () => {
  return (
    <div>
        <Navigation></Navigation>
        <WatchVideoPage/>
    </div>
  )
}

export default App