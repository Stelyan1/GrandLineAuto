(() => {
    const btn = document.querySelector(".nav-toggle");
    const links = document.querySelector("#navLinks");

    if (!btn || !links) return;

    const close = () => {
        links.classList.remove("open");
        btn.setAttribute("aria-expanded", "false");
    };

    btn.addEventListener("click", (e) => {
        e.stopPropagation();
        const open = links.classList.toggle("open");
        btn.setAttribute("aria-expanded", open ? "true" : "false");
    });

    // click outside closes
    document.addEventListener("click", close);

    // click on a nav item closes (mobile)
    links.addEventListener("click", (e) => {
        const a = e.target.closest("a");
        if (a) close();
    });

    // optional: Escape closes
    document.addEventListener("keydown", (e) => {
        if (e.key === "Escape") close();
    });
})();