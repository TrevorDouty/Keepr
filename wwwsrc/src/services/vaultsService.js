import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from '../services/AxiosService'

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
}
export const vaultsService = new VaultsService()