document.addEventListener('DOMContentLoaded', function () {
    // sidebar toggle
    const sidebarCollapse = document.getElementById('sidebarCollapse');
    const sidebar = document.getElementById('sidebar');
    if (sidebarCollapse) {
        sidebarCollapse.addEventListener('click', () => sidebar.classList.toggle('active'));
    }

    // global search (simple text filter for .searchable cards)
    const globalSearch = document.getElementById('globalSearch');
    if (globalSearch) {
        globalSearch.addEventListener('input', function (e) {
            const q = e.target.value.toLowerCase();
            document.querySelectorAll('.searchable').forEach(card => {
                const text = (card.innerText || card.textContent).toLowerCase();
                card.style.display = text.indexOf(q) > -1 ? '' : 'none';
            });
        });
    }

    // order item dynamic rows - if create order page exists
    document.querySelectorAll('.add-order-item').forEach(btn => {
        btn.addEventListener('click', () => {
            const container = document.querySelector('#orderItemsContainer');
            if (!container) return;
            // clone template
            const template = document.querySelector('#orderItemTemplate');
            const node = template.content.cloneNode(true);
            container.appendChild(node);
            attachRemoveHandlers();
        });
    });

    function attachRemoveHandlers() {
        document.querySelectorAll('.remove-order-item').forEach(r => {
            r.addEventListener('click', (e) => {
                const wrapper = e.target.closest('.order-item-row');
                if (wrapper) wrapper.remove();
            });
        });
    }
    attachRemoveHandlers();
});
