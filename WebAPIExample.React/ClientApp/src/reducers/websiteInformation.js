import { createSlice } from '@reduxjs/toolkit'

export const reducerWebsiteInformation = createSlice({
    name: 'WEBSITE_INFORMATION_REDUCER',
    initialState: {
        Name: null,
        Url: null,
        ResumeObjects:[],
        SkillsCategories:[],
    },
    reducers: {
      SAVE_WEBSITE_INFORMATION: (state, action) => {
        console.log('asd');
          state.Name = action.payload.Name;
          state.Url = action.payload.Url;
          state.ResumeObjects = action.payload.ResumeObjects;
          state.SkillsCategories = action.payload.SkillsCategories;
      },
    },
  })

export const { SAVE_WEBSITE_INFORMATION } = reducerWebsiteInformation.actions
export default reducerWebsiteInformation.reducer
