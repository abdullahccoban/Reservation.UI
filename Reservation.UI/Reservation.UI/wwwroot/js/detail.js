const comment_body = document.getElementById("comment_body");
const comment_button = document.getElementById("comment_button");

if (comment_button) {
    comment_button.addEventListener("click", async function(){
        comment_body.innerHTML = "\n" +
            "<div role=\"status\" class=\"flex justify-center p-6\">\n" +
            "    <svg aria-hidden=\"true\" class=\"w-6 h-6 text-gray-200 animate-spin fill-blue-600\" viewBox=\"0 0 100 101\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\">\n" +
            "        <path d=\"M100 50.5908C100 78.2051 77.6142 100.591 50 100.591C22.3858 100.591 0 78.2051 0 50.5908C0 22.9766 22.3858 0.59082 50 0.59082C77.6142 0.59082 100 22.9766 100 50.5908ZM9.08144 50.5908C9.08144 73.1895 27.4013 91.5094 50 91.5094C72.5987 91.5094 90.9186 73.1895 90.9186 50.5908C90.9186 27.9921 72.5987 9.67226 50 9.67226C27.4013 9.67226 9.08144 27.9921 9.08144 50.5908Z\" fill=\"currentColor\"/>\n" +
            "        <path d=\"M93.9676 39.0409C96.393 38.4038 97.8624 35.9116 97.0079 33.5539C95.2932 28.8227 92.871 24.3692 89.8167 20.348C85.8452 15.1192 80.8826 10.7238 75.2124 7.41289C69.5422 4.10194 63.2754 1.94025 56.7698 1.05124C51.7666 0.367541 46.6976 0.446843 41.7345 1.27873C39.2613 1.69328 37.813 4.19778 38.4501 6.62326C39.0873 9.04874 41.5694 10.4717 44.0505 10.1071C47.8511 9.54855 51.7191 9.52689 55.5402 10.0491C60.8642 10.7766 65.9928 12.5457 70.6331 15.2552C75.2735 17.9648 79.3347 21.5619 82.5849 25.841C84.9175 28.9121 86.7997 32.2913 88.1811 35.8758C89.083 38.2158 91.5421 39.6781 93.9676 39.0409Z\" fill=\"currentFill\"/>\n" +
            "    </svg>\n" +
            "    <span class=\"sr-only\">Loading...</span>\n" +
            "</div>\n";

        try {
            let hotelId = comment_button.dataset.hotelId;
            let response = await fetch(`/comment/getHotelComments?hotelId=${hotelId}`);
            let data = await response.json();

            comment_body.innerHTML = "";

            if (!data || data.length === 0) {
                comment_body.innerHTML = "<p class='text-gray-500 text-sm'>No comments yet.</p>";
                return;
            }

            data.forEach(item => {
                const created = new Date(item.createdAt).toLocaleDateString("tr-TR");

                const commentHtml = `
                <div class="p-6 bg-white border-b border-gray-200">
                    <div class="flex items-center gap-1">
                        <svg class="w-5 h-5 text-gray-500" xmlns="http://www.w3.org/2000/svg" fill="none"
                        viewBox="0 0 24 24">
                            <path stroke="currentColor" stroke-width="2"
                                d="M12 21a9 9 0 1 0 0-18 9 9 0 0 0 0 18Zm0 0a8.949 8.949 0 0 0 4.951-1.488A3.987 3.987 0 0 0 13 16h-2a3.987 3.987 0 0 0-3.951 3.512A8.948 8.948 0 0 0 12 21Zm3-11a3 3 0 1 1-6 0 3 3 0 0 1 6 0Z"/>
                        </svg>
                        <div class="flex flex-col gap-1 text-gray-500">
                            <p class="text-sm">Point: ${item.point}</p>
                            <p class="text-xs">${created}</p>
                        </div>
                    </div>
                    <p class="my-3 font-normal text-gray-700 text-sm">
                        ${item.comment}
                    </p>
                </div>
            `;

                comment_body.innerHTML += commentHtml;
            });

        } catch (err) {
            console.error(err);
            comment_body.innerHTML = "<p class='text-red-600'>Error loading comments</p>";
        }
    });
}

const qa_body = document.getElementById("qa_body");
const qa_button = document.getElementById("qa_button");

if (qa_button) {
    qa_button.addEventListener("click", async function(){
        qa_body.innerHTML = "\n" +
            "<div role=\"status\" class=\"flex justify-center p-6\">\n" +
            "    <svg aria-hidden=\"true\" class=\"w-6 h-6 text-gray-200 animate-spin fill-blue-600\" viewBox=\"0 0 100 101\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\">\n" +
            "        <path d=\"M100 50.5908C100 78.2051 77.6142 100.591 50 100.591C22.3858 100.591 0 78.2051 0 50.5908C0 22.9766 22.3858 0.59082 50 0.59082C77.6142 0.59082 100 22.9766 100 50.5908ZM9.08144 50.5908C9.08144 73.1895 27.4013 91.5094 50 91.5094C72.5987 91.5094 90.9186 73.1895 90.9186 50.5908C90.9186 27.9921 72.5987 9.67226 50 9.67226C27.4013 9.67226 9.08144 27.9921 9.08144 50.5908Z\" fill=\"currentColor\"/>\n" +
            "        <path d=\"M93.9676 39.0409C96.393 38.4038 97.8624 35.9116 97.0079 33.5539C95.2932 28.8227 92.871 24.3692 89.8167 20.348C85.8452 15.1192 80.8826 10.7238 75.2124 7.41289C69.5422 4.10194 63.2754 1.94025 56.7698 1.05124C51.7666 0.367541 46.6976 0.446843 41.7345 1.27873C39.2613 1.69328 37.813 4.19778 38.4501 6.62326C39.0873 9.04874 41.5694 10.4717 44.0505 10.1071C47.8511 9.54855 51.7191 9.52689 55.5402 10.0491C60.8642 10.7766 65.9928 12.5457 70.6331 15.2552C75.2735 17.9648 79.3347 21.5619 82.5849 25.841C84.9175 28.9121 86.7997 32.2913 88.1811 35.8758C89.083 38.2158 91.5421 39.6781 93.9676 39.0409Z\" fill=\"currentFill\"/>\n" +
            "    </svg>\n" +
            "    <span class=\"sr-only\">Loading...</span>\n" +
            "</div>\n";

        try {
            debugger;
            let hotelId = qa_button.dataset.hotelId;
            let response = await fetch(`/qa/getAnsweredQuestions?hotelId=${hotelId}`);
            let data = await response.json();

            qa_body.innerHTML = "";

            if (!data || data.length === 0) {
                qa_body.innerHTML = "<p class='text-gray-500 text-sm'>No Questions yet.</p>";
                return;
            }

            data.forEach(item => {
                const qaHtml = `
                <div class="p-1 bg-white">
                    <p class="flex items-center mb-6 text-sm text-gray-800">
                        <svg class="w-6 h-6 text-gray-800" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 17h6l3 3v-3h2V9h-2M4 4h11v8H9l-3 3v-3H4V4Z"/>
                        </svg>
                        ${item.question}
                    </p>
                    <p class="flex items-center mb-6 text-sm text-gray-800 bg-gray-100 p-3 rounded-lg">
                        ${item.answer}
                    </p>          
                </div>
            `;

                qa_body.innerHTML += qaHtml;
            });

        } catch (err) {
            console.error(err);
            qa_body.innerHTML = "<p class='text-red-600'>Error loading Q&As</p>";
        }
    });
}

const askQuestionForm = document.querySelector("#ask-modal form");
const question = document.getElementById("yourQuestion");

if (askQuestionForm) {
    askQuestionForm.addEventListener("submit", async(e) => {
        e.preventDefault();

        const payload = {
            hotelId: question.dataset.hotelId,
            question: question.value.trim()
        };

        const res = await fetch("/qa/ask", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(payload)
        });

        if (res.ok) location.reload();
    });
}
















