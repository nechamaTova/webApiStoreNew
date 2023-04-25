

const pageLoad = async () => {
    const products = await getAllProducts();
    const categories = await getAllCategories(products);

}

const getAllProducts = async () => {
    const response = await fetch("https://localhost:44333/api/Product", {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    const products = response.ok ? await response.json() : [];
    document.getElementById("PoductList").innerHTML = "";
    products.map((product) => {
        const temp = document.getElementById("temp-card");
        const clone = temp.content.cloneNode(true);
 
        clone.querySelector("img").src = `./images/${product.category.categoryId}/${product.imagePath}.jpg`
        clone.querySelector("h1").innerText = product.productName;
        clone.querySelector(".price").innerText = `${product.price} $`;
        clone.querySelector(".description").innerText = product.description;
        clone.querySelector("button").addEventListener("click", addToCart(product));
        document.getElementById("PoductList").appendChild(clone);
    })

    return products;


}

const getAllCategories = async (products) => {
    const response = await fetch("https://localhost:44333/api/Category", {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    const categories = response.ok ? await response.json() : [];
    categories.map((category) => {
        const temp = document.getElementById("temp-category");
        const clone = temp.content.cloneNode(true);
        clone.querySelector(".OptionName").innerText = category.categoryName;
        clone.querySelector(".Count").innerText = products.filter(p => p.category.categoryName == category.categoryName).length;
        document.getElementById("categoryList").appendChild(clone);
    })
    return categories;
}
const addToCart = (product) => {

}





document.addEventListener("load", pageLoad());