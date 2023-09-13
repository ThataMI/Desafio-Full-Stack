<template>
  <div>
    <h1>Cadastro de Empresas</h1>
    <Message :msg="msg" v-show="msg" />
    <form id="company-form">
      <div class="input-container-company">
        <label for="name">Nome:
        <input
          id="name"
          v-model="form.name"
          placeholder="Digite o nome da empresa"
        />
  </label>
    
        <label for="cnpj">Cnpj:
        <input
          id          = "cnpj"
          v-model     = "form.cnpj"
          placeholder = "Digite o cnpj da empresa"
        />
      </label>
      </div>
      <div class="input-container-company">
        <label for="cep">Cep:
        <input
          id="cep"
          v-model="form.cep"
          @change="checkCep"
          placeholder="Digite o cep da empresa"
        />
  </label>
      </div>
      <div class="input-container-company">
        <button class="submit-btn" type="button" @click="onSubmit">
          Cadastrar Empresa
        </button>
      </div>
    </form>
  </div>
</template>

<script>
import axios from "axios";
import Message from "./Message";

export default {
  name: "CompanyForm",
  data() {
    return {
      companies: [],
      form: {
        name: "",
        cnpj: "",
        cep: ""
      },
      msg: "",
      response: null,
    };
  },
  methods: {
    checkCep: async function (){
      if(this.form.cep.length == 8) {
				axios.get(`https://viacep.com.br/ws/${ this.form.cep }/json/`)
				.then( response => this.data = response.data )
				.catch( error => console.log(error) )
			}else
      alert("CEP Invalido!");
      },
      getCompanies() {
      axios
        .get("https://localhost:7237/api/companies/Get")
        .then((res) => {
          this.companies = res.data;
        })
        .catch(function (error) {
          console.error(error);
        });
      },
    onSubmit() {
      axios
        .post("https://localhost:7237/api/companies/Post", this.form)
        .then(() => {
          this.getCompanies();
          this.msg = "Cadastro realizado";
          setTimeout(() => (this.msg = ""), 3000);
        })
        .catch(function (error) {
          console.error(error);
        });
    },
  },

  components: {
    Message,
  },
};
</script>

<style scoped>
#company-form {
  margin: 0 auto;
  margin-bottom: 30px;
  display: flex;
  align-items: center;
  flex-direction: column;
}

.input-container-company {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  margin-bottom: 20px;
}

label {
  font-weight: bold;
  margin-bottom: 15px;
  color: #222;
  padding: 5px 10px;
  border-left: 4px solid #987bad;
}

input {
  padding: 5px 10px;
  width: 300px;
  border-radius: 10px;
  font-size: 16px;
  margin-top: 7px;
  border-color: #987bad;
}

.submit-btn {
  background-color: #222;
  color: #987bad;
  font-weight: bold;
  border: 2px solid #222;
  padding: 10px ;
  text-align: center;
  font-size: 16px;
  cursor: pointer;
  transition: 0.5s;
}

.submit-btn:hover {
  background-color: transparent;
  color: #222;
}
</style>
