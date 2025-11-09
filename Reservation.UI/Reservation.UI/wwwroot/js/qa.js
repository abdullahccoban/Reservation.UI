async function answer(id){
    
    var answer = document.getElementById(`answer_${id}`).value;

    const payload = {
        id: id,
        answer: answer.trim()
    };

    const res = await fetch("/qa/answer", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(payload)
    });
    
    if (res.ok) location.reload();
}