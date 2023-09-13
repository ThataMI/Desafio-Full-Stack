<template>
  <div class="main-container">
    <CompanyForm />
    <CompanyTable />
  </div>
</template>

<script>
import CompanyForm from "../components/CompanyForm.vue";
import CompanyTable from "../components/CompanyTable.vue";

export default {
  name: "Company",
  components: {
    CompanyForm,
    CompanyTable,
  },
};
</script>
