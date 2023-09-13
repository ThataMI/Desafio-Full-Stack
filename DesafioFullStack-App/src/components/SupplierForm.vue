<template>
  <div>
    <h1>Cadastro de Fornecedores</h1>
    <Message :msg="msg" v-show="msg" />
    <form id="supplier-form">
      <div class="input-container-supplier">
        <label for="name">Nome:
        <input
          id="name"
          v-model="form.name"
          placeholder="Digite o nome do fornecedor"
        />
      </label>
     
        <label for="cnpjCpf">Cnpj/Cpf:
        <input
          id          = "cnpjCpf"
          v-model     = "form.cnpjCpf"
          placeholder = "Digite o cnpj ou cpf"
          v-mask      = "['###.###.###-##', '##.###.###/####-##']"
        /></label>
      </div>
      <div class="input-container-supplier">
        <label for="cep">Cep:
        <input
          id="cep"
          v-model="form.cep"
         @change="checkCep"
          placeholder="Digite o cep da empresa"
        />
     </label>
    
        <label for="email">E-mail:
        <input
          id="email"
          v-model="form.email"
            
          placeholder="Digite o e-mail"
        /></label>
      </div>
      <div class="input-container-supplier">
        <label for="uf">Uf:
          
      <select v-model="form.uf">
        <option disabled value="">Escolha a UF</option>
        <option value="AC">Acre</option>
    <option value="AL">Alagoas</option>
    <option value="AP">Amapá</option>
    <option value="AM">Amazonas</option>
    <option value="BA">Bahia</option>
    <option value="CE">Ceará</option>
    <option value="DF">Distrito Federal</option>
    <option value="ES">Espírito Santo</option>
    <option value="GO">Goiás</option>
    <option value="MA">Maranhão</option>
    <option value="MT">Mato Grosso</option>
    <option value="MS">Mato Grosso do Sul</option>
    <option value="MG">Minas Gerais</option>
    <option value="PA">Pará</option>
    <option value="PB">Paraíba</option>
    <option value="PR">Paraná</option>
    <option value="PE">Pernambuco</option>
    <option value="PI">Piauí</option>
    <option value="RJ">Rio de Janeiro</option>
    <option value="RN">Rio Grande do Norte</option>
    <option value="RS">Rio Grande do Sul</option>
    <option value="RO">Rondônia</option>
    <option value="RR">Roraima</option>
    <option value="SC">Santa Catarina</option>
    <option value="SP">São Paulo</option>
    <option value="SE">Sergipe</option>
    <option value="TO">Tocantins</option>
    <option value="EX">Estrangeiro</option>
      </select>
       </label>
       <label for="rg" v-show="form.cnpjCpf.length == 14">Rg:
        <input
          id="rg"
          v-model="form.rg"
          placeholder="Digite o cep da empresa"
        />
   </label>
      </div>
      <div class="input-container-supplier" v-show="form.cnpjCpf.length == 14">
        
      
        <label for="birthday">Data de nascimento:
        <input
          id="birthday"
          v-model="form.birthday"
          type="date"
          placeholder="Digite o cep da empresa"
        /></label>
        
      </div>
     <button class = "submit-btn" type = "button" @click = "onSubmit">
          Cadastrar Fornecedor
        </button>
    </form>
  </div>
</template>

<script>
import axios from "axios";
import Message from "./Message";
import {mask} from 'vue-the-mask'

export default {
  name: "SupplierForm",
  data() {
    return {
      suppliers: [],
      form: {
        name: '',
        cnpjCpf: '',
        cep: '',
        email: '',
        uf: '',
        rg: '',
        birthday: null
      },
      msg: '',
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
      getSuppliers() {
        axios
          .get("https://localhost:7237/api/suppliers/GetAll")
          .then((res) => {
            this.suppliers = res.data;
          })
          .catch(function (error) {
            console.error(error);
          });
      },
      getAge(bDate){
        const today = new Date();
        const birthDate = new Date(bDate);
        let age = today.getFullYear() - birthDate.getFullYear();
        const m = today.getMonth() - birthDate.getMonth();
    
       if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
       }    
       return age;
      },
    onSubmit() {
      if(this.form.uf == "PR" && this.form.cnpjCpf.length == 14){
        const age = this.getAge(Date.parse(this.form.birthday));
        if(age < 18)
        {
          alert("Menor de 18 anos não pode ser fornecedor pessoa física no Paraná");
        }
        return
      }
      axios
        .post("https://localhost:7237/api/suppliers/Post", this.form)
        .then(() => {
          this.getSuppliers();
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
  directives: {mask},
};
</script>

<style scoped>
#supplier-form {
  margin: 0 auto;
  margin-bottom: 30px;
  display: flex;
  align-items: center;
  flex-direction: column;
}

.input-container-supplier {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  margin-bottom: 20px;
}

label {
  font-weight  : bold;
  margin-bottom: 15px;
  color        : #222;
  padding      : 5px 10px;
  border-left  : 4px solid #987bad;
}

input {
  padding: 5px 10px;
  width: 300px;
  border-radius: 10px;
  font-size: 16px;
  margin-top: 7px;
  border-color: #987bad;
}

select {
  padding: 5px 10px;
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
  font-size: 16px;
  cursor: pointer;
  transition: 0.5s;
}

.submit-btn:hover {
  background-color: transparent;
  color: #222;
}
</style>
