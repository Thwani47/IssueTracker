import { createSlice } from '@reduxjs/toolkit';

const initialState = {
	products: null
};

export const productsSlice = createSlice({
	name: 'products',
	initialState,
	reducers: {
		productsFetchSuccess: (state, action) => {
			state.products = action.payload.products;
		},
		clearProductsSuccess: (state) => {
			state.products = null;
		}
	}
});

export const { productsFetchSuccess, clearProductsSuccess } = productsSlice.actions;

export const setProducts = (products) => (dispatch) => {
	dispatch(productsFetchSuccess({ products }));
};

export const clearProducts = () => (dispatch) => {
	dispatch(clearProductsSuccess());
};

export default productsSlice.reducer;
