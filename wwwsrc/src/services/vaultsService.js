import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class VaultsService {
  async getVaults() {
    try {
      const res = await api.get('api/vaults')
      AppState.vaults = res.data
      logger.log(res.data)
    } catch (error) {
      logger.error(error)
    }
  }

  async createVault(newVault) {
    try {
      const res = await api.post('api/vaults', newVault)
      AppState.vaults = res.data
      this.getVaults()
    } catch (error) {
      logger.error(error)
    }
  }
}
export const vaultsService = new VaultsService()
