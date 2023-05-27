import { flowerType } from "./flowerType";


export type flowerArrangementType = {
    id: string;
    name: string;
    description: string;
    imageUrl: string;
    price: number;
    categoryName: string;
    flowers: Array<flowerType>;
};