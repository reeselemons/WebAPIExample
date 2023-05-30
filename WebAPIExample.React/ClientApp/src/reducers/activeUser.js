import { createSlice } from '@reduxjs/toolkit'

export const reducerActiveUser = createSlice({
    name: 'ACTIVE_USER',
    initialState: {
      activeUser: null,
    },
    reducers: {
      SAVE_USER: (state, action) => {
        state.activeUser = action.payload;
      },
    },
  })

  export const { SAVE_USER } = reducerActiveUser.actions
  export default reducerActiveUser.reducer

