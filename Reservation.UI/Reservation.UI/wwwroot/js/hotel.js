const name = document.getElementById("hotelName");
const description = document.getElementById("hotelDesc");
const dailyCapacity = document.getElementById("hotelCapacity");
const country = document.getElementById("hotelCountry");
const city = document.getElementById("hotelCity");
const phone = document.getElementById("hotelPhone");
const starCount = document.getElementById("hotelStar");
const errorMsg = document.getElementById("errorMsg");
const saveButton = document.getElementById('saveButton');

saveButton.addEventListener('click', (e) => {
    e.preventDefault();
    createHotel(name.value, description.value, dailyCapacity.value, country.value, city.value, phone.value, starCount.value);
})

async function createHotel(name, description, dailyCapacity, country, city, phone, starCount) {
    let formData = {
        name: name,
        description: description,
        dailyCapacity: dailyCapacity,
        country: country,
        city: city,
        phone: phone,
        starCount: starCount
    };

    let response = await fetch("/hotel/create", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    });

    if (response.ok) {
        location.reload();
    } else {
        errorMsg.classList.remove('hidden');
    }
}