
import { combineReducers } from 'redux'
import reducerWebsiteInformation from './websiteInformation'
import reducerActiveUser from './activeUser'

const allReducers = combineReducers({
    WebsiteInformation: reducerWebsiteInformation,
    ActiveUserSession: reducerActiveUser,
  });

export default allReducers;