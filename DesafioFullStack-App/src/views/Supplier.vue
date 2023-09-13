<template>
  <div class="main-container">
    <SupplierForm />
    <SupplierTable />
  </div>
</template>

<script>
import SupplierForm from "../components/SupplierForm.vue";
import SupplierTable from "../components/SupplierTable.vue";

export default {
  name: "Supplier",
  components: {
    SupplierForm,
    SupplierTable,
  },
};
</script>

